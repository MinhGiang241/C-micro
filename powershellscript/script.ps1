# write-output("please enter the first number")
# $first = [int](read-host)
# write-output("please enter the second number")
# $second = [int](read-host)
# write-output "$first + $second = $($first + $second)"

# count line file in folder
# dir . -filter "*.dart" -recurse -name | foreach{(gc $_).count} | measure-object -sum
# get-childitem -filter "*.dart" -recurse | get-content | measure-object -line
# get-childitem -filter *.dart -recurse | get-content | measure-object -word -line -character


# add a linecount property to each file project 
# $files = get-childitem 
# $files | foreach-object {
#   $nooflines = (get-content $_).length
#   $_ | add-member -notepropertymembers @{linecount = $nooflines}
#   }
# $files | format-table  -property @('name', 'linecount')

# if else 
# write-output 'do you like ?'
# $answer = read-host

# if ($answer -eq 'yes' -or $answer -eq 'y')
# {
#   write-output 'ok, thay good, you''re sane'
# } elseif($answer -eq 'no' -or $answer -eq 'n' )
# {
#   write-output 'i -i don''t even  know who i''m talking to'
# } else
# {
#   write-output 'i -i don''t  understand what you say'
# }

# $v = ''

# while ($v -eq '')
# {
#   $v = read-host "enter something"
# }


# $per =-1
# while($per -lt 0 -or $per -gt 100 )
# {
#   $per = [int](read-host("enter pecenage"))
# }

# $i=1

# while($i -lt 10)
# {
#   # code repeat here
#   $i +=1
#   write-output("w're current $i")
# }

# $arr = @('a','b','c')

# foreach($v in $arr)
# {
#   foreach($i in 0..10)
#   {
#     write-output("$v : $i")
#   }
# }


# function say 
# {
#   param(
#   [parameter()][string]$message,
#   [parameter()][string]$count
#   )
#   write-output("Hello $message $count")
# }
# say "hello" "ll"

# function get-something
# {
#     param
#     (
#          [parameter(mandatory=$true, position=0)]
#          [string] $name,
#          [parameter(mandatory=$true, position=1)]
#          [int] $id
#     )
# }

# param([parameter()][System.IO.FileInfo[]]$Files) 

# $hashes = $Files | ForEach-Object {(Get-FileHash $_).Hash}

# $hashes = Get-ChildItem | ForEach-Object {(Get-FileHash $_).Hash}


# $matching = $true
# foreach ($hash in $hashes)
# {
#   Write-Output($hash)
#   for ($i =0; $i -lt  $hashes.length ; $i++)
#   {

#     if($hash -ne $hashes[$i])
#     {
#       $matching = $false
#     }
#   }
# }
# if($matching -eq $true)
# {
#   Write-Output("Matchnh hass")

# } else
# {
#   Write-Host("Not matching hash")
# }

function Set-Name
{
  Write-Host("Old Name: $name")
  $script:name = 'Tom'
  Write-Host "new name: $name"
}

$name = [string](read-host "enter name")
Set-Name
Set-Name
