import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/book-store',
        name: '::Menu:BookStore',
        iconClass: 'fas fa-book',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/books',
        name: '::Menu:Books',
        parentName: '::Menu:BookStore',
        layout: eLayoutType.application,
        requiredPolicy: 'Desafio.Books'
      },
      {
        path: '/authors',
        name: '::Menu:Authors',
        parentName: '::Menu:BookStore',
        layout: eLayoutType.application,
        requiredPolicy: 'Desafio.Authors',
      },
      {
        path: '/pessoas-management',
        name: '::Menu:PersonsManagement',
        iconClass: 'fas fa-book',
        order: 3,
        layout: eLayoutType.application,
      },
      {
        path: '/pessoas',
        name: '::Menu:Persons',
        parentName: '::Menu:PersonsManagement',
        layout: eLayoutType.application,
        requiredPolicy: 'Desafio.Persons',
      }
      
      
    ]);
  };
}
