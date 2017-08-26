using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class TabelaProcedController : Base                                 
    {                                                                               
        internal TabelaProced _TabelaProced { get; set; }                 
                                                                                    
        public TabelaProcedController()                                        
        {                                                                           
            _TabelaProced = new TabelaProced();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionTabelaProced = _TabelaProced.GetAll().ToList(); 
            return View(collectionTabelaProced);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new TabelaProcedDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(TabelaProcedDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var TabelaProced = new TabelaProced();                    
                _TabelaProced.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

