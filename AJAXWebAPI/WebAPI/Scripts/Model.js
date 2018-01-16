class Pokemon
{
    constructor(nombrePokemon,habilidad1,generacion,habitat)
    {
        this._nombrePokemon = nombrePokemon;
        this._habilidad1 = habilidad1;
        this._generacion = generacion;
        this._habitat = habitat;
    }
    get nombrePokemon()
    {
        return this._nombrePokemon;
    }
    get habilidad1()
    {
        return this._habilidad1;
    }
    get generacion()
    {
        return this._generacion;
    }
    get habitat()
    {
        return this._habitat;
    }
    set habilidad1(value)
    {
        this._habilidad1 = value;
    }
    set generacion(value)
    {
        this._generacion = value;
    }
    set habitat(value)
    {
        this._habitat = value;
    }
    set nombrePokemon(value)
    {
        this._nombrePokemon = value;
    }

}