using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventManagementSystem.Models;
using EventManagementSystem.Repositories;

namespace EventManagementSystem.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventRepository _repository;

        public EventsController(IEventRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var events = await _repository.GetAllEventsAsync();
            return View(events);
        }

        [HttpGet]
        [Route("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var ev = await _repository.GetEventByIdAsync(id);
            if (ev == null)
            {
                return NotFound();
            }
            return View(ev);
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View(new Event());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public async Task<IActionResult> Create(Event ev)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddEventAsync(ev);
                TempData["SuccessMessage"] = "Event scheduled successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(ev);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var ev = await _repository.GetEventByIdAsync(id);
            if (ev == null)
            {
                return NotFound();
            }
            return View(ev);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id, Event ev)
        {
            if (id != ev.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _repository.UpdateEventAsync(ev);
                TempData["SuccessMessage"] = "Event details updated successfully!";
                return RedirectToAction(nameof(Details), new { id = ev.Id });
            }
            return View(ev);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteEventAsync(id);
            TempData["SuccessMessage"] = "Event deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        #region Inline Budgets Actions
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("details/{eventId}/budget/add")]
        public async Task<IActionResult> AddBudget(int eventId, Budget budget)
        {
            if (ModelState.IsValid)
            {
                budget.EventId = eventId;
                await _repository.AddBudgetAsync(budget);
                TempData["SuccessMessage"] = "Budget item added successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add budget item. Verify input values.";
            }
            return RedirectToAction(nameof(Details), new { id = eventId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("details/{eventId}/budget/delete/{id}")]
        public async Task<IActionResult> DeleteBudget(int eventId, int id)
        {
            await _repository.DeleteBudgetAsync(id);
            TempData["SuccessMessage"] = "Budget item removed.";
            return RedirectToAction(nameof(Details), new { id = eventId });
        }
        #endregion

        #region Inline Tasks Actions
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("details/{eventId}/task/add")]
        public async Task<IActionResult> AddTask(int eventId, TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                taskItem.EventId = eventId;
                await _repository.AddTaskItemAsync(taskItem);
                TempData["SuccessMessage"] = "Operational milestone added!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add task. Verify details.";
            }
            return RedirectToAction(nameof(Details), new { id = eventId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("details/{eventId}/task/delete/{id}")]
        public async Task<IActionResult> DeleteTask(int eventId, int id)
        {
            await _repository.DeleteTaskItemAsync(id);
            TempData["SuccessMessage"] = "Task removed.";
            return RedirectToAction(nameof(Details), new { id = eventId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("details/{eventId}/task/status/{id}")]
        public async Task<IActionResult> UpdateTaskStatus(int eventId, int id, string status)
        {
            if (!string.IsNullOrEmpty(status))
            {
                await _repository.UpdateTaskItemStatusAsync(id, status);
                TempData["SuccessMessage"] = "Task status updated!";
            }
            return RedirectToAction(nameof(Details), new { id = eventId });
        }
        #endregion

        [HttpGet]
        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

