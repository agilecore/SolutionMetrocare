using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class AgendaController : Base                                 
    {                                                                               
        internal Agenda _Agenda { get; set; }                 
                                                                                    
        public AgendaController()                                        
        {                                                                           
            _Agenda = new Agenda();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionAgenda = _Agenda.GetAll().ToList(); 
            return View(collectionAgenda);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new AgendaDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(AgendaDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var Agenda = new Agenda();                    
                _Agenda.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

