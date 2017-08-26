using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class PlanoTabelaController : Base                                 
    {                                                                               
        internal PlanoTabela _PlanoTabela { get; set; }                 
                                                                                    
        public PlanoTabelaController()                                        
        {                                                                           
            _PlanoTabela = new PlanoTabela();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionPlanoTabela = _PlanoTabela.GetAll().ToList(); 
            return View(collectionPlanoTabela);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new PlanoTabelaDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(PlanoTabelaDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var PlanoTabela = new PlanoTabela();                    
                _PlanoTabela.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

