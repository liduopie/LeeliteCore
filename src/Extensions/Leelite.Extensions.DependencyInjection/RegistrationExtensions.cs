using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Extensions.DependencyInjection
{
    public static class RegistrationExtensions
    {
        public static RegistrationData AsInterface(this RegistrationData registration)
        {
            ArgumentNullException.ThrowIfNull(registration);

            return AsInterface(registration, c => true); ;
        }

        public static RegistrationData AsInterface(this RegistrationData registration, Func<Type, bool> predicate)
        {
            ArgumentNullException.ThrowIfNull(registration);

            registration.As(type => type.GetInterfaces().Where(c => predicate(c)));

            return registration;
        }

        public static RegistrationData AsSelf(this RegistrationData registration)
        {
            ArgumentNullException.ThrowIfNull(registration);

            registration.As(type => new List<Type>() { type });

            return registration;
        }

        public static RegistrationData Singleton(this RegistrationData registration)
        {
            ArgumentNullException.ThrowIfNull(registration);

            registration.With(ServiceLifetime.Singleton);

            return registration;
        }

        public static RegistrationData Scope(this RegistrationData registration)
        {
            ArgumentNullException.ThrowIfNull(registration);

            registration.With(ServiceLifetime.Scoped);

            return registration;
        }

        public static RegistrationData Transient(this RegistrationData registration)
        {
            ArgumentNullException.ThrowIfNull(registration);

            registration.With(ServiceLifetime.Transient);

            return registration;
        }
    }
}
