import { Component, OnInit } from '@angular/core';
import { CategoryModel } from '../Models/category.model';
import { CategoryService } from '../Services/category.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  loadedCategories: CategoryModel[];
  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.categoryService.fetchCategories().subscribe(categories => {
      this.loadedCategories = categories;
        
      })
    }
  }

