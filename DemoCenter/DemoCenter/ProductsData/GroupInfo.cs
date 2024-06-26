﻿using DemoCenter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCenter.ProductsData
{
    public class GroupInfo : ProductInfoBase
    {
        public List<PageInfo> Pages { get; set; }

        public override bool HasChildren => Pages.Count > 0;

        public GroupInfo(string name, string title, string description, Func<PageViewModelBase> viewModel, List<PageInfo> pages, ProductBageType? bageType = null, bool showInWeb = true)
        {
            Name = name;
            Title = title;
            Description = description;
            ViewModelGetter = viewModel;
            Pages = pages;
            BageType = bageType;
            ShowInWeb = showInWeb;
        }
    }
}
