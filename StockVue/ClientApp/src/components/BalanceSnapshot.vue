<template>
    <v-row>
        <v-col lg="12" md="12">
            <v-card>
                <v-list-item three-line>
                    <v-list-item-content>
                        <div class="text-center">Account value / Today's net change</div>
                        <v-list-item-title class="text-center font-weight-bold text-h6" v-html="`<span>$</span>${item.balance}`"></v-list-item-title>
                        <v-list-item-subtitle class="text-center" v-html="`<span>$</span>${item.netChgVal} <span>(${item.netChgPct}%)</span>`"></v-list-item-subtitle>
                    </v-list-item-content>
                </v-list-item>
            </v-card>
        </v-col>
    </v-row>
</template>
<script>
    export default {
        name: 'BalanceSnapshot',
        data() {
            return {
                item: 
                    {
                        balance: 12345.67,
                        netChgVal: 12.34,
                        netChgPct: 0.89
                    }                
            }
        }
    }
</script>