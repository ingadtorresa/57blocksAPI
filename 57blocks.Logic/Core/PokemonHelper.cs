using _57blocks.Logic.Models;
using _57blocks.Model.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _57blocks.Logic.Core
{
    public class PokemonHelper
    {
        public static bool Create(PokemonModel item)
        {
            bool result = false;
            try
            {
                using (BlockEntities context = new BlockEntities())
                {
                    UserLogin user = context.UserLogin.Where(o => o.Email == item.Email).FirstOrDefault();
                    if (user != null)
                    {
                        Pokemon pokemon = new Pokemon();
                        pokemon.UserloginId = user.UserloginId;
                        pokemon.Name = item.Name;
                        pokemon.TypePrincipal = item.TypePrincipal;
                        pokemon.TypeAlternate = item.TypeAlternate;
                        pokemon.Level = item.Level;
                        pokemon.PC = item.PC;
                        context.Pokemon.Add(pokemon);
                        context.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return result;
        }

        public static string GetAll()
        {
            try
            {
                List<Pokemon> pokemons = new List<Pokemon>();
                using (BlockEntities context = new BlockEntities())
                {
                    var pokemonsd = context.Pokemon.Select(x => new
                    {
                        x.PokemonId,
                        x.Name,
                        x.TypePrincipal,
                        x.TypeAlternate,
                        x.Level,
                        x.PC,
                    }).ToList();
                    return JsonConvert.SerializeObject(pokemonsd);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return string.Empty;
        }

        public static string GetMyElements(string email)
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            try
            {
                using (BlockEntities context = new BlockEntities())
                {
                    UserLogin userLogin = context.UserLogin.Where(o => o.Email == email).FirstOrDefault();
                    if (userLogin != null)
                    {
                        var pokemonsd = context.Pokemon.Where(o => o.UserloginId == userLogin.UserloginId).Select(x => new
                        {
                            x.PokemonId,
                            x.Name,
                            x.TypePrincipal,
                            x.TypeAlternate,
                            x.Level,
                            x.PC,
                        }).ToList();

                        return JsonConvert.SerializeObject(pokemonsd);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return string.Empty;
        }

        public static bool Update(PokemonModel item)
        {
            bool result = false;
            try
            {
                using (BlockEntities context = new BlockEntities())
                {
                    UserLogin userLogin = context.UserLogin.Where(o => o.Email == item.Email).FirstOrDefault();
                    if (userLogin != null)
                    {
                        Pokemon currentPokemon = context.Pokemon.Where(o => o.PokemonId == item.PokemonId && o.UserloginId == userLogin.UserloginId).FirstOrDefault();
                        if (currentPokemon != null)
                        {
                            currentPokemon.Name = item.Name;
                            currentPokemon.TypePrincipal = item.TypePrincipal;
                            currentPokemon.TypeAlternate = item.TypeAlternate;
                            currentPokemon.Level = item.Level;
                            currentPokemon.PC = item.PC;
                            context.SaveChanges();
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return result;
        }

        public static bool Delete(PokemonModel item)
        {
            bool result = false;
            try
            {
                using (BlockEntities context = new BlockEntities())
                {
                    UserLogin userLogin = context.UserLogin.Where(o => o.Email == item.Email).FirstOrDefault();
                    if (userLogin != null)
                    {
                        Pokemon currentPokemon = context.Pokemon.Where(o => o.PokemonId == item.PokemonId && o.UserloginId == userLogin.UserloginId).FirstOrDefault();
                        if (currentPokemon != null)
                        {
                            context.Pokemon.Remove(currentPokemon);
                            context.SaveChanges();
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return result;
        }

        public static bool DeleteAll(string email)
        {
            bool result = false;
            try
            {
                using (BlockEntities context = new BlockEntities())
                {
                    UserLogin userLogin = context.UserLogin.Where(o => o.Email == email).FirstOrDefault();
                    if (userLogin != null)
                    {
                        List<Pokemon> pokemonList = context.Pokemon.Where(o => o.UserloginId == userLogin.UserloginId).ToList();
                        if (pokemonList != null)
                        {
                            context.Pokemon.RemoveRange(pokemonList);
                            context.SaveChanges();
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return result;
        }
    }
}
