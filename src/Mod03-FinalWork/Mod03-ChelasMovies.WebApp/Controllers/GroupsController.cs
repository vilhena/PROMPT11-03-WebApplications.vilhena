using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mod03_ChelasMovies.DomainModel.Services;
using Mod03_ChelasMovies.DomainModel.Domain;
using Mod03_ChelasMovies.WebApp.Models;

namespace Mod03_ChelasMovies.WebApp.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;


        public GroupsController(IGroupService groupService, IUserService userService)
        {
            _groupService = groupService;
            _userService = userService;
        }

        //
        // GET: /Groups/

        public ActionResult Index()
        {
            return View(_groupService.GetAllMyGroups(User.Identity.Name));
        }

        //
        // GET: /Groups/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Groups/Create

        [HttpPost]
        public ActionResult Create(GroupCreateModel group)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Group newGroup = new Group();
                    newGroup.Name = group.Name;
                    newGroup.Owner = _userService.GetAuthenticatedUser(User.Identity.Name);
                    newGroup.Permissions = new ACL();
                    newGroup.Permissions.Read = group.Read;
                    newGroup.Permissions.Change = group.Change;
                    newGroup.Permissions.Delete = group.Delete;

                    _groupService.Add(newGroup);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", String.Format("Edit Failure, inner exception: {0}", e));
            }

            return View(group);
        }


        //
        // GET: /Groups/Edit/1
        public ActionResult Edit(int id)
        {
            return View(_groupService.Get(id));
        }


        //
        // GET: /Groups/AddUser/1
        public ActionResult AddUser(int GroupID)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(GroupAddUserModel gAddUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _groupService.AddUserToGroup(gAddUser.GroupID, gAddUser.Username);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", String.Format("Edit Failure, inner exception: {0}", e));
            }

            return View(gAddUser);
        }

        public ActionResult Details(int id)
        {
            var group = _groupService.Get(id);
            var detailsView = new GroupDevailsModel()
            {
                ID = group.ID,
                Name = group.Name,
                Read = group.Permissions.Read,
                Change = group.Permissions.Change,
                Delete = group.Permissions.Delete,
            };
            return View(detailsView);
        }

    }
}
