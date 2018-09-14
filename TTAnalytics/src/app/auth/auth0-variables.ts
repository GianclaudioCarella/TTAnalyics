interface AuthConfig {
  clientID: string;
  domain: string;
  callbackURL: string;
}

export const AUTH_CONFIG: AuthConfig = {
  clientID: '1jHwQXIHCxA75GKgJuwUJJ8URN3feuWj',
  domain: 'gianclaudiocarella.auth0.com',
  callbackURL: 'http://localhost:4500/callback'
};
