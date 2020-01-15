# NET.W.2019.Shevchenko.17

В текстовом файле построчно хранится информация о URL-адресах, представленных в виде **&lt;scheme&gt;://&lt;host&gt;/&lt;URL‐path&gt;?&lt;parameters&gt;**, где сегмент `parameters` - это набор пар вида `key=value`, при этом сегменты `URL‐path` и `parameters`
или сегмент `parameters` могут отсутствовать.

Разработать систему типов (руководствоваться принципами SOLID) для экспорта данных, полученных на основе разбора информации текстового файла, в XML-документ по следующему правилу. Например, для текстового файла с URL-адресами

```
https://github.com/AnzhelikaKravchuk?tab=repositories
https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU
https://habrahabr.ru/company/it-grad/blog/341486/
```

результирующим является XML-документ вида (можно использовать любую XML технологию без ограничений):

```
<?xml version="1.0" encoding="utf-8"?>
<urlAddresses>
  <urlAddress>
    <host name="github.com" />
    <uri>
      <segment>AnzhelikaKravchuk</segment>
    </uri>
    <parameters>
      <parameter key="tab" value="repositories" />
    </parameters>
  </urlAddress>
  <urlAddress>
    <host name="github.com" />
    <uri>
      <segment>AnzhelikaKravchuk</segment>
      <segment>2017-2018.MMF.BSU</segment>
    </uri>
  </urlAddress>
  <urlAddress>
    <host name="habrahabr.ru" />
    <uri>
      <segment>company</segment>
      <segment>it-grad</segment>
      <segment>blog</segment>
      <segment>341486</segment>
    </uri>
  </urlAddress>
</urlAddresses>
```

Для тех URL-адресов, которые не совпадают с данным паттерном, &laquo;залогировать&raquo; информацию, отметив указанные строки, как необработанные.

Продемонстрировать работу на примере консольного приложения.
