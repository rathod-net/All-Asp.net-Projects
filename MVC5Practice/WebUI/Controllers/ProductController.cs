using BAL;
using DAL.DataEntities;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ICategoryServices _catServices; IProductServices _productServices;
        public ProductController(ICategoryServices catServices, IProductServices productServices)
        {
            _catServices = catServices;
            _productServices = productServices;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var categories = _catServices.GetAllCategories();
            ViewBag.categories = new SelectList(categories, "CategoryId", "Name", "Rating");
            var products = _productServices.GetAllProducts();
            return View(products);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var product = _productServices.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

       

        [HttpGet]
        public ActionResult Create()
        {
            var categories = _catServices.GetAllCategories();
            ViewBag.categories = new SelectList(categories, "CategoryId", "Name", "Rating");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product != null)
                {
                    _productServices.CreateProduct(product);
                   return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Massage = "Reqired All filed Fill to Create Product";
                }
            }
            ViewBag.Categories = new SelectList(_catServices.GetAllCategories(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var categories = _catServices.GetAllCategories();
            ViewBag.categories = new SelectList(categories, "CategoryId", "Name", "Rating");
            var product = _productServices.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product != null)
                {
                    _productServices.UpdateProduct(product);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Massage = "Reqired All filed Fill to Create Product";
                }
            }
            ViewBag.Categories = new SelectList(_catServices.GetAllCategories(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = _productServices.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if(id != null)
            {
                _productServices.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Massage = "Please Give Proper Product name";
            }
            return View();
        }
       

    }
}

