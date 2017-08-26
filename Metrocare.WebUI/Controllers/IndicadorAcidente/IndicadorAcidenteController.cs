using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class IndicadorAcidenteController : Base                                 
    {                                                                               
        internal IndicadorAcidente _IndicadorAcidente { get; set; }                 
                                                                                    
        public IndicadorAcidenteController()                                        
        {                                                                           
            _IndicadorAcidente = new IndicadorAcidente();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionIndicadorAcidente = _IndicadorAcidente.GetAll().ToList(); 
            return View(collectionIndicadorAcidente);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new IndicadorAcidenteDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(IndicadorAcidenteDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var IndicadorAcidente = new IndicadorAcidente();                    
                _IndicadorAcidente.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

