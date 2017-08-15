delimiter $$

drop procedure if exists sp_adiciona_beneficiario$$

create definer=`saude`@`%` procedure `sp_adiciona_beneficiario`(
  in v_id_usuario       int          , 
  in v_id_carteira      int          , 
  in v_id_beneficiario  int          ,         
  in v_nome             varchar(255) ,
  in v_cpf              varchar(30)  ,
  in v_rg               varchar(30)  ,
  in v_email            varchar(15)  ,
  in v_logradouro       varchar(255) ,
  in v_complemento      varchar(255) ,
  in v_numero           int          ,
  in v_cep              int          ,
  in v_bairro           varchar(255) ,
  in v_cidade           varchar(255) ,
  in v_uf               varchar(2)   ,
  in v_telefone         varchar(15)  ,
  in v_celular          varchar(15)  ,
  in v_dt_cadastro      date         ,
  in v_dt_nascimento    date         ,
  in v_longitude        int          ,
  in v_latitude         int          ,
  in v_ibge             int          
)
begin


    if exists (select id_beneficiario from beneficiario where id_beneficiario = v_id_beneficiario) then

        update beneficiario 
           set id_usuario      = v_id_usuario     ,
			   id_carteira     = v_id_carteira    ,
			   nome            = v_nome           ,                       
               cpf             = v_cpf            , 
               rg              = v_rg             , 
               email           = v_email          ,               
               logradouro      = v_logradouro     ,               
               complemento     = v_complemento    ,               
               numero          = v_numero         ,               
               cep             = v_cep            ,               
               bairro          = v_bairro         ,               
               cidade          = v_cidade         ,               
               uf              = v_uf             ,               
               telefone        = v_telefone       ,               
               celular         = v_celular        ,   
               dt_cadastro     = v_dt_cadastro    ,     
			   dt_nascimento   = v_dt_nascimento  ,			   
               longitude       = v_longitude      ,               
               latitude        = v_latitude       ,                
               ibge            = v_ibge           
         where id_beneficiario = v_id_beneficiario;
         commit;

    else

        insert into beneficiario 
        (
		    id_usuario         ,
			id_carteira        ,
            id_beneficiario    ,
            nome               , 
            cpf                ,
            rg                 ,
            email              ,
            logradouro         ,
            complemento        ,
            numero             ,
            cep                ,
            bairro             ,
            cidade             ,
            uf                 ,
            telefone           ,
            celular            ,
            dt_cadastro        ,
			dt_nascimento      ,
            longitude          ,
            latitude           ,
            ibge            
        )                    
        values               
        (  
		    v_id_usuario       ,
			v_id_carteira      ,		
            v_id_beneficiario  ,        
            v_nome             ,
            v_cpf              ,
            v_rg               ,
            v_email            ,
            v_logradouro       ,
            v_complemento      ,
            v_numero           ,
            v_cep              ,
            v_bairro           ,
            v_cidade           ,
            v_uf               ,
            v_telefone         ,
            v_celular          ,
            v_dt_cadastro      ,
			v_dt_nascimento    ,
            v_longitude        ,
            v_latitude         ,
            v_ibge          
        );  
        commit;

    end if;

end$$

delimiter ;

