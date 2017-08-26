using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class PeriodoController : Base                                 
    {                                                                               
        internal Periodo _Periodo { get; set; }                 
                                                                                    
        public PeriodoController()                                        
        {                                                                           
            _Periodo = new Periodo();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionPeriodo = _Periodo.GetAll().ToList(); 
            return View(collectionPeriodo);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new PeriodoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(PeriodoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var Periodo = new Periodo();                    
                _Periodo.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

