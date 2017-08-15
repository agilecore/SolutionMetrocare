delimiter $$

drop procedure if exists sp_plano_categoria$$
 
create procedure sp_plano_categoria
(   
	in v_id_plano_categoria int          ,
    in v_nome               varchar(255) 
)
begin

    if exists (select id_plano_categoria from plano_categoria where id_plano_categoria = v_id_plano_categoria) then

        update plano_categoria 
           set nome = v_nome
         where id_plano_categoria = v_id_plano_categoria;
         commit;

    else

        insert into plano_categoria 
        (
            id_plano_categoria,        
            nome    
        )                    
        values               
        (     
            v_id_plano_categoria,        
            v_nome          
        );  
        commit;

    end if;

end$$ 

delimiter ;