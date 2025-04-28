using Core.Entities;
using Core.Inputs;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace SampleStoreApi.Controllers
{
	[ApiController]
	[Route("/[controller]")]
	public class BookController : ControllerBase
	{
		private readonly IBookRepository _bookRepository;

		public BookController(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				var booksDto = new List<BookDto>();

				var books = _bookRepository.SelectAll();

				foreach (var book in books)
				{
					booksDto.Add(new BookDto
					{
						Id = book.Id,
						Name = book.Name,
						Publisher = book.Publisher,
						CreationDate = book.CreationDate,
						Orders = book.Orders.Select(o => new Order()
						{
							CustomerId = o.CustomerId,
							BookId = o.BookId
						}).ToList()
					});
				}

				return Ok(booksDto);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("{id:int}")]
		public IActionResult Get([FromRoute] int id)
		{
			try
			{
				var book = _bookRepository.SelectById(id);

				if (book is null)
				{
					return NotFound();
				}

				return Ok(book);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		//public async ValueTask<IActionResult> Post([FromBody] BookInput bookInput)
		[HttpPost]
		public IActionResult Post([FromBody] BookInput bookInput)
		{
			try
			{
				var book = new Book
				{
					Name = bookInput.Name,
					Publisher = bookInput.Publisher,
				};

				_bookRepository.Insert(book);

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut]
		public IActionResult Put([FromBody] BookUpdateInput bookUpdateInput)
		{
			try
			{
				var book = _bookRepository.SelectById(bookUpdateInput.Id);

				if (book is null)
				{
					return NotFound();
				}

				book.Name = bookUpdateInput.Name;
				book.Publisher = bookUpdateInput.Publisher;

				_bookRepository.Update(book);

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id:int}")]
		public IActionResult Delete([FromRoute] int id)
		{
			try
			{
				var result = _bookRepository.Delete(id);

				if (result is false)
				{
					return NotFound();
				}

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("CreateManyBooks")]
		public IActionResult CreateManyBooks()
		{
			try
			{
				try
				{
					var livros = new List<Book>()
					{
						new() { Name = "Book 1", Publisher = "Publisher" },
						new() { Name = "Book 2", Publisher = "Publisher" },
						new() { Name = "Book 3", Publisher = "Publisher" },
						new() { Name = "Book 4", Publisher = "Publisher" },
						new() { Name = "Book 5", Publisher = "Publisher" },
						new() { Name = "Book 6", Publisher = "Publisher" },
						new() { Name = "Book 7", Publisher = "Publisher" },
						new() { Name = "Book 8", Publisher = "Publisher" },
						new() { Name = "Book 9", Publisher = "Publisher" },
						new() { Name = "Book 10", Publisher = "Publisher" },
					};

					_bookRepository.InsertMany(livros);

					return Ok();
				}
				catch (Exception e)
				{
					return BadRequest(e.Message);
				}
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}
