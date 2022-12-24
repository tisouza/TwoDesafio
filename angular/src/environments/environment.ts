import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Desafio',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44385/',
    redirectUri: baseUrl,
    clientId: 'Desafio_App',
    responseType: 'code',
    scope: 'offline_access Desafio',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44385',
      rootNamespace: 'Two.Desafio',
    },
  },
} as Environment;
