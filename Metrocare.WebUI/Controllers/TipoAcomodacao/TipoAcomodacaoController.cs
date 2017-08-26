using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class TipoAcomodacaoController : Base                                 
    {                                                                               
        internal TipoAcomodacao _TipoAcomodacao { get; set; }                 
                                                                                    
        public TipoAcomodacaoController()                                        
        {                                                                           
            _TipoAcomodacao = new TipoAcomodacao();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionTipoAcomodacao = _TipoAcomodacao.GetAll().ToList(); 
            return View(collectionTipoAcomodacao);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new TipoAcomodacaoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(TipoAcomodacaoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var TipoAcomodacao = new TipoAcomodacao();                    
                _TipoAcomodacao.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

