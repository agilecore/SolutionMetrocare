delimiter $$

drop procedure if exists sp_adiciona_prestador$$

create definer=`saude`@`%` procedure `sp_adiciona_prestador`(   
  in v_id_prestador  int          ,         
  in v_nome          varchar(255) ,
  in v_cpf           varchar(30)  ,
  in v_cnpj          varchar(30)  ,
  in v_email         varchar(15)  ,
  in v_logradouro    varchar(255) ,
  in v_complemento   varchar(255) ,
  in v_numero        int          ,
  in v_cep           int          ,
  in v_bairro        varchar(255) ,
  in v_cidade        varchar(255) ,
  in v_uf            varchar(2)   ,
  in v_telefone      varchar(15)  ,
  in v_celular       varchar(15)  ,
  in v_contato       varchar(255) ,
  in v_dt_cadastro   date         ,
  in v_longitude     int          ,
  in v_latitude      int          ,
  in v_ibge          int          
)
begin


    if exists (select id_prestador from prestador where id_prestador = v_id_prestador) then

        update prestador 
           set nome         = v_nome        ,                       
               cpf          = v_cpf         ,               
               cnpj         = v_cnpj        ,               
               email        = v_email       ,               
               logradouro   = v_logradouro  ,               
               complemento  = v_complemento ,               
               numero       = v_numero      ,               
               cep          = v_cep         ,               
               bairro       = v_bairro      ,               
               cidade       = v_cidade      ,               
               uf           = v_uf          ,               
               telefone     = v_telefone    ,               
               celular      = v_celular     ,               
               contato      = v_contato     ,               
               dt_cadastro  = v_dt_cadastro ,               
               longitude    = v_longitude   ,               
               latitude     = v_latitude    ,               
               ibge         = v_ibge         
         where id_prestador = v_id_prestador;
         commit;

    else

        insert into prestador 
        (
            id_prestador    ,
            nome            , 
            cpf             ,
            cnpj            ,
            email           ,
            logradouro      ,
            complemento     ,
            numero          ,
            cep             ,
            bairro          ,
            cidade          ,
            uf              ,
            telefone        ,
            celular         ,
            contato         ,
            dt_cadastro     ,
            longitude       ,
            latitude        ,
            ibge            
        )                    
        values               
        (     
            v_id_prestador  ,        
            v_nome          ,
            v_cpf           ,
            v_cnpj          ,
            v_email         ,
            v_logradouro    ,
            v_complemento   ,
            v_numero        ,
            v_cep           ,
            v_bairro        ,
            v_cidade        ,
            v_uf            ,
            v_telefone      ,
            v_celular       ,
            v_contato       ,
            v_dt_cadastro   ,
            v_longitude     ,
            v_latitude      ,
            v_ibge          
        );  
        commit;

    end if;

end$$

delimiter ;

