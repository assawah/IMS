﻿namespace PM.Models
{
    public class ScopePackageDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ScopePackageId { get; set; }
        public ScopePackage ScopePackage { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
