create procedure InsertIntoAddressBook
(
  @firstName varchar(100),
  @lastName varchar(100),
  @address varchar(200),
  @city varchar(50),
  @state varchar(100),
  @zipCode bigint,
  @phoneNumber bigint,
  @email varchar(50)
)
as
begin
insert into AddressBookTable(firstName,lastName,address,city,state,zipCode,phoneNumber,email) values(@firstName,@lastName,@address,@city,@state,@zipCode,@phoneNumber,@email)
end