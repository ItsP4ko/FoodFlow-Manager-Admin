FoodFlowM
#22/05/2025#

se Subio el proyecto a github
se completo Roles y permisos, (solo falta apartado de roles a roles)
se termino admin cocina, cajero y apartado de cadeteria dentro de AdminAdmin
COSAS QUE FALTAN TODAVIA

apartado de roles a roles dentro de amdin admin
apartado de reportes dentro de admin restaurante (pensar por lo menos dos reportes)
agregar en todas las funciones del proyecto el apartado de tiene permiso? (La funcion TienePermiso, ya esta creada dentro de la controladora de seguridad, es nomas chequear si el rol el cual esta tratando de acceder tiene o no tiene permiso a esa funcionalidad, y luego crear los roles, crear roles genericos, con el nombre del usuario como para mostarle al profesor que funciona. no es necesario crear todos los permisos, que cada rol tenga su permiso y que el rol admin admin tenga tdos los permisos.)
FIN DIA

#23/05/2025# 
Correccion del eliminarlines(), dentro de las funciones del cajero para los pedidos ya creados. a su vez se actualizo lo siguiente:

-todos los precios se modificaron de float a decimal(18,2)
-cada aderezopedidoplato ahora tiene su precio momento, al igual que cada pedidoplato lo mismo
-cuando se elimina un plato de un pedido, es decir , eliminar una linea. se actualiza el total de dicho pedido

CONCLUSION: esto fue hecho para que, al modificar el precio de un plato o un aderezo en un futuro, no distorsione los precios de los aderezo o platos de los pedidios ya existente.
