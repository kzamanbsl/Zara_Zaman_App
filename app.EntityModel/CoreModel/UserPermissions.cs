﻿namespace app.EntityModel.CoreModel
{
    public class UserPermissions : BaseEntity
    {
        public string UserId { get; set; }
        public long MenuItemId { get; set; }
        public int OrderNo { get; set; }
    }
}
