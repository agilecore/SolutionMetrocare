using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class AltaController : Base                                 
    {                                                                               
        internal Alta _Alta { get; set; }                 
                                                                                    
        public AltaController()                                        
        {                                                                           
            _Alta = new Alta();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionAlta = _Alta.GetAll().ToList(); 
            return View(collectionAlta);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new AltaDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(AltaDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var Alta = new Alta();                    
                _Alta.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

