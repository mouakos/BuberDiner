﻿using BuberDinner.Application.Dinners.Commands.CreateDinner;
using BuberDinner.Application.Dinners.Queries.ListDinners;
using BuberDinner.Contracts.Dinners;
using BuberDinner.Domain.DinnerAggregate;
using Mapster;

namespace BuberDiner.Api.Common.Mapping
{
    public class DinnerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateDinnerRequest Request, Guid HostId), CreateDinnerCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Guid, ListDinnersQuery>()
                .MapWith(src => new ListDinnersQuery(src));

            config.NewConfig<Dinner, DinnerResponse>()
                .Map(dest => dest.Id, src => src.Id.Value.ToString())
                .Map(dest => dest.Status, src => src.Status.Value)
                .Map(dest => dest.MenuId, src => src.MenuId.Value)
                .Map(dest => dest.HostId, src => src.HostId.Value);
        }
    }
}