using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using HoldPlease.Models;


namespace HoldPlease.Controllers
{
    public class ServiceController : Controller
    {
        private readonly HoldPleaseContext _context;

        public ServiceController(HoldPleaseContext context)
        {
            _context = context;    
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

        // POST: Service/Accept/5
        public async Task<IActionResult> Accept(int? serviceId)
        {
            if (serviceId == null)
                return NotFound();

            var service = await _context.Service.SingleOrDefaultAsync(mx => mx.ID == serviceId);
            if (service == null)
                return NotFound();

            // TODO check if the current user is the serviceProvider for the service.
            // If they are return a particular service

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
                return RedirectToAction("Index");
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
