using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PLASTIC_WARFARE_PROJ.DbContextData;
using PLASTIC_WARFARE_PROJ.Models;
using PLASTIC_WARFARE_PROJ.Repos;
using PLASTIC_WARFARE_PROJ.ViewModels;

namespace PLASTIC_WARFARE_PROJ.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IPlasticWarfareRepo repo;
       
        public OrdersController(IPlasticWarfareRepo context)
        {
            
            repo = context;
        }
        
        // GET: Orders
        public async Task<IActionResult> Index()
        {
            try
            {
                var orders = repo.GetOrderListForParticularUser(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                //отсеять те что выполнены
                orders = orders.Where(o => o.IsChecked == false).ToList();
                var colors = repo.GetColors();
                var plasticTypes = repo.GetPlasticTypes();
                var ordersVM = new OrderVM();

                ordersVM.Orders = orders;
                ordersVM.Colors = colors;
                ordersVM.PlasticTypes = plasticTypes;
                return View(ordersVM);
            }
            catch
            {
                var orders = repo.GetOrderListForParticularUser(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                //отсеять те что выполнены
                orders = orders.Where(o => o.IsChecked == false).ToList();
                var colors = repo.GetColors();
                var plasticTypes = repo.GetPlasticTypes();
                var ordersVM = new OrderVM();

                ordersVM.Orders = orders;
                ordersVM.Colors = colors;
                ordersVM.PlasticTypes = plasticTypes;
                return View(ordersVM);
            }
        }
       
        public async Task<IActionResult> PendingOrders()
        {
            try
            {
                var orders = repo.GetOrderListForParticularUser(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                //отсеять те что выполнены
                orders = orders.Where(o=>o.IsChecked==false).ToList();
                var colors = repo.GetColors();
                var plasticTypes = repo.GetPlasticTypes();
                var ordersVM = new OrderVM();

                ordersVM.Orders = orders;
                ordersVM.Colors = colors;
                ordersVM.PlasticTypes = plasticTypes;
                return View(ordersVM);
            }
            catch
            {
                var orders = repo.GetOrderListForParticularUser(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                //отсеять те что выполнены
                orders = orders.Where(o => o.IsChecked == false).ToList();
                var colors = repo.GetColors();
                var plasticTypes = repo.GetPlasticTypes();
                var ordersVM = new OrderVM();

                ordersVM.Orders = orders;
                ordersVM.Colors = colors;
                ordersVM.PlasticTypes = plasticTypes;
                return View(ordersVM);
            }
           

        }

        public async Task<IActionResult> ProcessedOrders()
        {
            try
            {
                var orders = repo.GetOrderListForParticularUser(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                //отсеять те что не выполнены
                orders = orders.Where(o => o.IsChecked == false).ToList();

                var colors = repo.GetColors();
                var plasticTypes = repo.GetPlasticTypes();
                var ordersVM = new OrderVM();

                ordersVM.Orders = orders;
                ordersVM.Colors = colors;
                ordersVM.PlasticTypes = plasticTypes;
                return View(ordersVM);
            }
            catch
            {
                var orders = repo.GetOrderListForParticularUser(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                //отсеять те что выполнены
                orders = orders.Where(o => o.IsChecked == false).ToList();
                var colors = repo.GetColors();
                var plasticTypes = repo.GetPlasticTypes();
                var ordersVM = new OrderVM();

                ordersVM.Orders = orders;
                ordersVM.Colors = colors;
                ordersVM.PlasticTypes = plasticTypes;
                return View(ordersVM);
            }



        }




        // GET: Orders/Create
        public IActionResult Create()
        {
            var orders = repo.GetAllOrders();
            var colors = repo.GetColors();
            var plasticTypes = repo.GetPlasticTypes();
            var ordersVM = new OrderVM();

            ordersVM.Orders = orders;
            ordersVM.Colors = colors;
            ordersVM.PlasticTypes = plasticTypes;
            return View(ordersVM);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdditionalDescription,PlasticTypeId,ColorId")] Order order,IFormFileCollection stls)
        {
            List<Render_STL> rendersToDownload = new List<Render_STL>();
            if (order != null)
            {
                foreach (var item in stls)
                {
                    var renderStlTmp = new Render_STL();
                    //сохранение файла в локальную папку.
                  
                    renderStlTmp.Path = Path.Combine("wwwroot/renders", item.FileName);
                    using (var stream = new FileStream(renderStlTmp.Path, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                    renderStlTmp.Name = item.Name;
                    renderStlTmp.Size = (int)new FileInfo(renderStlTmp.Path).Length;
                    rendersToDownload.Add(renderStlTmp);
                }
                order.ModelsAmount = stls.Count;
                order.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                repo.CreateOrder(order, rendersToDownload);

                return RedirectToAction(nameof(Index));
            }
                
            

            var orders = repo.GetAllOrders();
            var colors = repo.GetColors();
            var plasticTypes = repo.GetPlasticTypes();
            var ordersVM = new OrderVM();

            ordersVM.Orders = orders;
            ordersVM.Colors = colors;
            ordersVM.PlasticTypes = plasticTypes;
            return View(ordersVM);
        }

       
       

       
    }
}
