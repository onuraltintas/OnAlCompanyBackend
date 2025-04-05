using AutoMapper;
using OnalCompany.Domain.Entities;
using OnAlCompany.Application.Features.Contacts.Queries.GetAll;
using OnAlCompany.Application.Features.Contacts.Queries.GetById;

namespace OnAlCompany.Application.Features.Contacts.Mapping;

public sealed class ContactMapping : Profile
{
    public ContactMapping()
    {
        CreateMap<Contact, GetAllContactsQueryResponse>();
        CreateMap<Contact, GetContactByIdQueryResponse>();
    }
} 