Building A Form


1. Create a Action To view Form
1.1. CustomerController.cs > *New()..return view()
1.2. right click on view() add view.


2. Create form using Html + Adding checkbox
2.0. @model Vidly.Models.Customer
2.1. @using (Html.BeginForm('Create', 'Customers'))
		<div class='form-group'>
			@Html.LabelFor(m =>m.Name)
			@Html.TextBoxFor(m => m.Name, new {@class = 'form-control'})
		<div>
		<div class="checkbox">
			<label>
				@Html.CheckBoxFor(m => m.Customer.IsSubscribedToNewsletter) Subscribed to Newsletter?
			</label>
		</div>


3. Changing Labels from model
3.1. Model > Customer.cs
3.2. add *[Display(Name = 'Date of Birth')] * before property


4. Drop-Down Lists
4.1. IndentityModule.cs> add new DbSet Property
4.2. *public DbSet<MemberShipType> MemberShipTypes
4.3. Inside CustomerController.cs > New()
4.4. *var membershipTypes = _context.MembershipTypes.ToList()
4.5. Inside ViewModel > new class NewCustomerViewModel.cs
4.6. * public IEnumerable<MembershipType> MembershipTypes {get; set;}
	   public Customer Customer { get; set; }
4.7. Back to CustomerController.cs
4.8. * var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }
4.9. Inside New.cshtml
4.10. @model Vidly.ViewModels.NewCustomerViewModel
4.11. replace m.Name to m.Customer.Name (for all)
4.12. * <div class="form-group">
			@Html.LabelFor(m => m.Customer.MembershipTypeId)
			@Html.DropDownListFor(m => m.Customer.MembershipTypeId, new SelectList(Model.MembershipTypes, "Id", "Name"), "Select Membership Type", new { @class = "form-control" })
		</div>
4.13. Compile and check!

5. Model Binding
5.1. Adding a button in end
5.2. *<button type="submit" class="btn btn-primary">Save</button>
5.3. Inside CustomerController.cs create Create()
5.4. use a [HttpPost] before the class
5.5. add a parameter Create(NewCustomerViewModel ViewModel)
5.6. binding helps to identify model property 
5.7. write instead *public ActionResult Create(Customer customer)

6. Saving Data
6.1. Inside CustomerController.cs> Create>
		_context.Customers.Add(customer);
		_context.SaveChanges();
		return RedirectToAction('Index', 'Customer')

7. Edit Form
7.1. Inside Index.cshtml change details into Edit
7.2. Create New ActionResult Edit(int id)
7.3. * var customer = _context.Customers.SingleOrDefault(c =>c.Id == id);
		if (customer ==null)
			return HttpNotFound()
		var viewModel = new NewCustomerViewModel
		{
			Customer = customer,
			MembershipTypes = _context.MembershupTypes.ToList()
		};

		return View("New", viewModel)

7.4. NewCustomerViewModel => CustomerFormViewModel
	 New => CustomerForm
	 add "CustomerForm" inside return of New()
7.5. Inside CustomerForm> Birthdate add a second argument
		*"{0:d MMM yyyy}"

8. Update Data
8.1. Rename Create>save from both controller and form.cshtml
8.2. inside save
8.3. ** [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
               _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }