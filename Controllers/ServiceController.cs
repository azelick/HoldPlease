using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HoldPlease.Models;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace HoldPlease.Controllers
{
    public class ServiceController : Controller
    {
        private readonly HoldPleaseContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ServiceController(HoldPleaseContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: Service
        public async Task<IActionResult> Index()
        {
            return View(await _context.Service.ToListAsync());
        }

        // GET: Service/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .SingleOrDefaultAsync(m => m.ID == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Service/AddNotification/5/3
        public async Task<IActionResult> AddNotification(string id, string userId)
        {
            int intId = 0;

            Int32.TryParse(id, out intId);

            

            var service = await _context.Service
                .SingleOrDefaultAsync(m => m.ID == intId);

            var users = _userManager.Users.Where(u => u.Id == userId).ToList();
            if (users.Count > 0)
            {
                var user = users[0];
                if (service.notified == null)
                {
                    service.notified = user.Email;
                } else {
                    service.notified = service.notified + "," + user.Email;
                }

                await _context.SaveChangesAsync();
                
                return StatusCode(200);
            }
            return StatusCode(500);
        }

        // GET: Service/BrowseProviders/5
        public async Task<IActionResult> BrowseProviders(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .SingleOrDefaultAsync(m => m.ID == id);
            if (service == null)
            {
                return NotFound();
            }

            var users = _userManager.Users.Where(u => u.costAvailability != null).ToList();
            List<ApplicationUser> matchingUsers = new List<ApplicationUser>();

            for (int i = 0; i < users.Count; i++)
            {
                
                if (users[i].costAvailability != null)
                {
                    Dictionary<string, string> costAvailability = JsonConvert.DeserializeObject<Dictionary<string, string>>(users[i].costAvailability);
                    var startTime = Convert.ToDateTime(costAvailability["start"]);
                    var endTime = Convert.ToDateTime(costAvailability["end"]);
                    if (service.startAt.TimeOfDay >= startTime.TimeOfDay && service.endAt.TimeOfDay <= endTime.TimeOfDay)
                    {
                        matchingUsers.Add(users[i]);
                    }
                }

            }
            ViewBag.matchingUsers = matchingUsers;

            return View(service);
        }

        // GET: Service/ChangeStatus/5
        [Authorize]
        public async Task<IActionResult> ChangeStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service.SingleOrDefaultAsync(m => m.ID == id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: Service/ChangeService/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeService(int id, [Bind("status")] Service service)
        {
            
            if (id != service.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View(service);
            }
            return View(service);
        }

        // POST: Service/AcceptService/4
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AcceptedService(int? serviceId)
        {
            //we want to update the database to say that a particular user 
            //is now the service provider. After that we 
            if (serviceId == null)
                return NotFound();

            // get the service from the db
            var service = await _context.Service.SingleOrDefaultAsync(m => m.ID == serviceId);
            // get the current service 
            var serviceProvider = User.Identity.Name;
            // assign the service provider as the services provider
            service.serviceProviderId = serviceProvider;
            // add the service back to the DB
            _context.Service.Add(service);
			await _context.SaveChangesAsync();

			return View(service);
        }

        // GET: Service/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name,clientId,serviceProviderId,status,location,startAt,endAt")] Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(service);
        }
        
        // GET: Service/NewRequest
        [Authorize]
        public IActionResult NewRequest()
        {
            return View();
        }

        
        // POST: Service/NewRequest
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewRequest([Bind("ID,name,clientId,serviceProviderId,status,location,startAt,endAt")] Service service)
        {
            if (ModelState.IsValid)
            {
                service.clientId = User.Identity.Name;
                service.status = "Requested";
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction("BrowseProviders", new {id = service.ID});
            }
            return View(service);
        }

        // GET: Service/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service.SingleOrDefaultAsync(m => m.ID == id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: Service/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name,clientId,serviceProviderId,status,location,startAt,endAt")] Service service)
        {
            if (id != service.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(service);
        }

        // GET: Service/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .SingleOrDefaultAsync(m => m.ID == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.Service.SingleOrDefaultAsync(m => m.ID == id);
            _context.Service.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ServiceExists(int id)
        {
            return _context.Service.Any(e => e.ID == id);
        }
    }
}
