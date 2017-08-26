using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class DependenteController : Base                                 
    {                                                                               
        internal Dependente _Dependente { get; set; }                 
                                                                                    
        public DependenteController()                                        
        {                                                                           
            _Dependente = new Dependente();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionDependente = _Dependente.GetAll().ToList(); 
            return View(collectionDependente);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new DependenteDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(DependenteDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var Dependente = new Dependente();                    
                _Dependente.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

