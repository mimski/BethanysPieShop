﻿using BethanysPieShop.Repositories;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class HomeController : Controller
{
    private readonly IPieRepository pieRepository;

    public HomeController(IPieRepository pieRepository)
    {
        this.pieRepository = pieRepository;
    }

    public IActionResult Index()
    {
        var piesOfTheWeek = this.pieRepository.PiesOfTheWeek;
        var homeViewModel = new HomeViewModel(piesOfTheWeek);

        return View(homeViewModel);
    }
}
