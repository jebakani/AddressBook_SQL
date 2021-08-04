create procedure SortedOrder
as 
begin
select personId,firstName,lastName,address,city,state,zipCode,phoneNumber,email from AddressBook order By firstName 
end
