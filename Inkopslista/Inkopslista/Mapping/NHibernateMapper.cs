using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inkopslista.Models;

namespace Inkopslista.Mapping
{
    public class NHibernateMapper
    {
        private readonly ModelMapper _modelMapper;

        public NHibernateMapper()
        {
            _modelMapper = new ModelMapper();
        }

        public HbmMapping Map()
        {
            //MapSubstantiv();
            //MapTheme();
            //MapAdjektiv();
            MapIngrediens();
            return _modelMapper.CompileMappingForAllExplicitlyAddedEntities();
        }
        private void MapIngrediens()
        {
            _modelMapper.Class<Ingrediens>(e =>
            {
                e.Id(p => p.Id, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.Name);
            });
        }
    }
}