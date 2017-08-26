using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class TipoGuiaSaidaController : Base                                 
    {                                                                               
        internal TipoGuiaSaida _TipoGuiaSaida { get; set; }                 
                                                                                    
        public TipoGuiaSaidaController()                                        
        {                                                                           
            _TipoGuiaSaida = new TipoGuiaSaida();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionTipoGuiaSaida = _TipoGuiaSaida.GetAll().ToList(); 
            return View(collectionTipoGuiaSaida);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new TipoGuiaSaidaDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(TipoGuiaSaidaDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var TipoGuiaSaida = new TipoGuiaSaida();                    
                _TipoGuiaSaida.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

