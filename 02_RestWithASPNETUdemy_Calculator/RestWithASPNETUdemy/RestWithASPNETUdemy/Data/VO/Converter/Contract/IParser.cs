using System.Collections.Generic;

namespace RestWithASPNETUdemy.Data.VO.Converter.Contract
{
    public interface IParser<O, D>
    {
        D Parse(O origin);
        O Parse(D origin);
        List<D> Parse(List<O> origin);
        List<O> Parse(List<D> origin);
    }
}
