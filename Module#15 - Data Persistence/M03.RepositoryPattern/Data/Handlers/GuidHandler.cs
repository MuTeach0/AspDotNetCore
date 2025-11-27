using System.Data;
using Dapper;

namespace M03.RepositoryPattern.Data.Handlers;

public class GuidHandler : SqlMapper.TypeHandler<Guid>
{
    public override Guid Parse(object value) =>
        Guid.Parse((string)value);

    public override void SetValue(IDbDataParameter parameter, Guid value) =>
        parameter.Value = value.ToString();
}