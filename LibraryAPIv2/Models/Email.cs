﻿namespace LibraryAPIv2.Models;

public class Email
{
    public Guid Id { get; set; }
    public string To { get; set; }
    public string Body { get; set; }
}
