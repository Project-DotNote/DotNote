//namespace DotNote.Services.Tests
//{
//    using Moq;
//    using Xunit;

//    using System;
//    using System.Threading.Tasks;
//    using System.Collections.Generic;
//    using System.Linq;

//    using Microsoft.AspNetCore.Mvc;
//    using Microsoft.EntityFrameworkCore;

//    using Web.Controllers;          
//    using DotNote.Data.Models;
//    using DotNote.Data;


//    public class NoteControllerTests
//    {
//        [Fact]
//        public void Index_ReturnsViewWithNotes()
//        {
//            var mockDbSet = new Mock<DbSet<Note>>();
//            var notes = new List<Note>
//            {
//                new Note { Id = Guid.NewGuid(), Title = "Note 1" },
//                new Note { Id = Guid.NewGuid(), Title = "Note 2" },
//                new Note { Id = Guid.NewGuid(), Title = "Note 3" }
//            };
//            mockDbSet.As<IQueryable<Note>>().Setup(m => m.Provider).Returns(notes.AsQueryable().Provider);
//            mockDbSet.As<IQueryable<Note>>().Setup(m => m.Expression).Returns(notes.AsQueryable().Expression);
//            mockDbSet.As<IQueryable<Note>>().Setup(m => m.ElementType).Returns(notes.AsQueryable().ElementType);
//            mockDbSet.As<IQueryable<Note>>().Setup(m => m.GetEnumerator()).Returns(notes.AsQueryable().GetEnumerator());

//            var mockContext = new Mock<DotNoteDbContext>();
//            mockContext.Setup(c => c.Notes).Returns(mockDbSet.Object);

//            var controller = new NoteController(mockContext.Object);

//            var result = controller.Index();

//            var viewResult = Assert.IsType<ViewResult>(result);
//            var model = Assert.IsAssignableFrom<IEnumerable<Note>>(viewResult.ViewData.Model);
//            Assert.Equal(notes.Count, model.Count());
//        }

//        [Fact]
//        public async Task Create_Post_ReturnsRedirectToIndex()
//        {
//            var mockContext = new Mock<DotNoteDbContext>();
//            var controller = new NoteController(mockContext.Object);
//            var note = new Note();

//            var result = await controller.Create(note);

//            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
//            Assert.Equal("Index", redirectToActionResult.ActionName);
//        }

//        [Fact]
//        public async Task Edit_Post_ReturnsRedirectToIndex()
//        {
//            var mockContext = new Mock<ApplicationDbContext>();
//            var controller = new NoteController(mockContext.Object);
//            var note = new Note { Id = Guid.NewGuid() };

//            var result = await controller.Edit(note.Id, note);

//            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
//            Assert.Equal("Index", redirectToActionResult.ActionName);
//        }

//        [Fact]
//        public async Task DeleteConfirmed_Post_ReturnsRedirectToIndex()
//        {
//            var mockContext = new Mock<ApplicationDbContext>();
//            var controller = new NoteController(mockContext.Object);
//            var noteId = Guid.NewGuid();

//            var result = await controller.DeleteConfirmed(noteId);

//            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
//            Assert.Equal("Index", redirectToActionResult.ActionName);
//        }
//    }

//    public class CalendarControllerTests
//    {
//        [Fact]
//        public void Index_ReturnsViewWithEvents()
//        {
//            var mockDbSet = new Mock<DbSet<Event>>();
//            var events = new List<Event>
//            {
//                new Event { Id = Guid.NewGuid(), Name = "Event 1" },
//                new Event { Id = Guid.NewGuid(), Name = "Event 2" },
//                new Event { Id = Guid.NewGuid(), Name = "Event 3" }
//            };
//            mockDbSet.As<IQueryable<Event>>().Setup(m => m.Provider).Returns(events.AsQueryable().Provider);
//            mockDbSet.As<IQueryable<Event>>().Setup(m => m.Expression).Returns(events.AsQueryable().Expression);
//            mockDbSet.As<IQueryable<Event>>().Setup(m => m.ElementType).Returns(events.AsQueryable().ElementType);
//            mockDbSet.As<IQueryable<Event>>().Setup(m => m.GetEnumerator()).Returns(events.AsQueryable().GetEnumerator());

//            var mockContext = new Mock<ApplicationDbContext>();
//            mockContext.Setup(c => c.Events).Returns(mockDbSet.Object);

//            var controller = new CalendarController(mockContext.Object);

//            var result = controller.Index();

//            var viewResult = Assert.IsType<ViewResult>(result);
//            var model = Assert.IsAssignableFrom<IEnumerable<Event>>(viewResult.ViewData.Model);
//            Assert.Equal(events.Count, model.Count());
//        }

//        [Fact]
//        public async Task Create_Post_ReturnsRedirectToIndex()
//        {
//            var mockContext = new Mock<ApplicationDbContext>();
//            var controller = new CalendarController(mockContext.Object);
//            var calendarEvent = new Event();

//            var result = await controller.Create(calendarEvent);

//            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
//            Assert.Equal("Index", redirectToActionResult.ActionName);
//        }

//        [Fact]
//        public async Task Edit_Post_ReturnsRedirectToIndex()
//        {
//            var mockContext = new Mock<ApplicationDbContext>();
//            var controller = new CalendarController(mockContext.Object);
//            var calendarEvent = new Event { Id = Guid.NewGuid() };

//            var result = await controller.Edit(calendarEvent.Id, calendarEvent);

//            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
//            Assert.Equal("Index", redirectToActionResult.ActionName);
//        }

//        [Fact]
//        public async Task DeleteConfirmed_Post_ReturnsRedirectToIndex()
//        {
//            var mockContext = new Mock<ApplicationDbContext>();
//            var controller = new CalendarController(mockContext.Object);
//            var eventId = Guid.NewGuid();

//            var result = await controller.DeleteConfirmed(eventId);

//            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
//            Assert.Equal("Index", redirectToActionResult.ActionName);
//        }
//    }
//}