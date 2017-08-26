using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class DiaController : Base                                 
    {                                                                               
        internal Dia _Dia { get; set; }                 
                                                                                    
        public DiaController()                                        
        {                                                                           
            _Dia = new Dia();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionDia = _Dia.GetAll().ToList(); 
            return View(collectionDia);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new DiaDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(DiaDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var Dia = new Dia();                    
                _Dia.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

