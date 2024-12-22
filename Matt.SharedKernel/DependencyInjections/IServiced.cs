namespace Matt.SharedKernel.DependencyInjections;

public interface IServiced;

public interface ISingleton : IServiced;

public interface ITransient : IServiced;

public interface IScoped : IServiced;