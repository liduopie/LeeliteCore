import { AuthorizationModule } from './authorization.module';

describe('ApiAuthorizationModule', () => {
  let apiAuthorizationModule: AuthorizationModule;

  beforeEach(() => {
    apiAuthorizationModule = new AuthorizationModule();
  });

  it('should create an instance', () => {
    expect(apiAuthorizationModule).toBeTruthy();
  });
});
