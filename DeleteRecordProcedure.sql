create procedure DeleteRecord
(
@id int,
@firstName Varchar(100)
)
as
begin
delete from AddressBookTable where firstName=@firstName and personId=@id 
end