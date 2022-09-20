﻿using DemoLib.DataAccess.Models;
using MediatR;

namespace DemoLib.Queries;

public record GetPersonListQuery() : IRequest<List<PersonModel>>;
