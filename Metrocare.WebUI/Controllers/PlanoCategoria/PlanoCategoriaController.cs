using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class PlanoCategoriaController : Base                                 
    {                                                                               
        internal PlanoCategoria _PlanoCategoria { get; set; }                 
                                                                                    
        public PlanoCategoriaController()                                        
        {                                                                           
            _PlanoCategoria = new PlanoCategoria();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionPlanoCategoria = _PlanoCategoria.GetAll().ToList(); 
            return View(collectionPlanoCategoria);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new PlanoCategoriaDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(PlanoCategoriaDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var PlanoCategoria = new PlanoCategoria();                    
                _PlanoCategoria.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

