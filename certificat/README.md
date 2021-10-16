## Files required for frontend

```
bitad_ath_bielsko_pl.crt
bitad_ath_bielsko_pl.key
```

## Files required for api

```
bitad_ath_bielsko_pl.pfx
```

### You can generate \*.pfx file by this command in bash:

```
openssl pkcs12 -export -in ./bitad_ath_bielsko_pl.crt -inkey ./bitad_ath_bielsko_pl.key -out bitad_ath_bielsko_pl.pfx
```
