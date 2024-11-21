using ArticulosAPI.Data;
using ArticulosAPI.Dto;
using AutoMapper;
using ArticulosAPI.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ArticulosAPI.Repositorio;

public class Repositorio : IRepositorio
{
    private readonly ApplicationDbContext _context;
    private IMapper _mapper;
    public Repositorio(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ArticuloDto> CrearOActualizar(ArticuloDto articuloDto, int id = 0)
    {
        var articulo = _mapper.Map<ArticuloDto, Articulos>(articuloDto);
        if (id == 0)
        {

            await _context.Articulos.AddAsync(articulo);
        }
        else
        {
            articulo.Id = id;
        }

        await _context.SaveChangesAsync();
        return _mapper.Map<Articulos, ArticuloDto>(articulo);
    }

    public async Task<bool> EliminarArticulo(int id)
    {
        var persona = await _context.Articulos.FindAsync(id);
        if (persona != null)
        {
            _context.Articulos.Remove(persona);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<List<ArticuloDto>> GetArticulos()
    {
        List<Articulos> articulos = await _context.Articulos.ToListAsync();

        return _mapper.Map<List<Articulos>, List<ArticuloDto>>(articulos);
    }

    public async Task<ArticuloDto> GetArticuloById(int id)
    {
        var articulo = await _context.Articulos.FindAsync(id);
        if (articulo != null) return _mapper.Map<Articulos, ArticuloDto>(articulo);
        return null!;
    }
}