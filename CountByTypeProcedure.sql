create procedure CountByType
as
begin
select count(personId) from AddressBookTable group by bookType
end