﻿namespace PerfTest.Api.Dtos;

public class CustomerDto
{
    public string CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public AddressDto Address { get; set; }
}
