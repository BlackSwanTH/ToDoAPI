using System;
using System.Collections.Generic;

namespace ToDoAPI.Models;

public partial class Activity
{
    public uint Id { get; set; }
    public string User_Id { get; set; } // เพิ่มเอง

    public string Name { get; set; } = null!;

    public DateTime When { get; set; }
}
