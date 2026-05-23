using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DenzelDev.Models;
using DenzelDev.Repositories;

namespace DenzelDev.Controllers
{
    public class EventsController : Controller
    {
        private readonly IPortfolioRepository _repository;

        public EventsController(IPortfolioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("events")]
        public async Task<IActionResult> Index()
        {
            var events = await _repository.GetAllEventsAsync();
            return View(events);
        }

        [HttpGet]
        [Route("events/{id}")]
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
        [Route("events/create")]
        public IActionResult Create()
        {
            return View(new Event());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("events/create")]
        public async Task<IActionResult> Create(Event ev)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddEventAsync(ev);
                TempData["SuccessMessage"] = "Event created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(ev);
        }

        [HttpGet]
        [Route("events/edit/{id}")]
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
        [Route("events/edit/{id}")]
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
        [Route("events/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteEventAsync(id);
            TempData["SuccessMessage"] = "Event deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        #region Inline Budgets Actions
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("events/{eventId}/budget/add")]
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
        [Route("events/{eventId}/budget/delete/{id}")]
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
        [Route("events/{eventId}/task/add")]
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
        [Route("events/{eventId}/task/delete/{id}")]
        public async Task<IActionResult> DeleteTask(int eventId, int id)
        {
            await _repository.DeleteTaskItemAsync(id);
            TempData["SuccessMessage"] = "Task removed.";
            return RedirectToAction(nameof(Details), new { id = eventId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("events/{eventId}/task/status/{id}")]
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
    }
}
